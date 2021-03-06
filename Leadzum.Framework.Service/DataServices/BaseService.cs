﻿using AutoMapper;
using Leadzum.Framework.Data;
using Leadzum.Framework.DomainModel;
using Leadzum.Framework.DomainModel.Enumerations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leadzum.Framework.Service
{
    public class BaseService: IDisposable
    {
        private static object exceptionLogLock = new object();
        protected readonly IMapper Mapper;
        protected readonly IServiceProvider serviceProvider;
        protected readonly IServiceScope serviceScope;

        public BaseService(IServiceProvider serviceProvider, IMapper mapper)
        {
            this.serviceProvider = serviceProvider;
            serviceScope = serviceProvider.CreateScope();
            Mapper = mapper;
        }
        protected async Task<FuncResult<T>> QueryAsync<T>(Func<ApplicationDbContext, Task<FuncResult<T>>> lambda)
        {
            var result = new FuncResult<T>();
            try
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            result = await lambda(dbContext);
                            dbContextTransaction.Commit();
                        }
                        catch (ThreadInterruptedException tie)
                        {
                            throw tie;
                        }
                        catch (Exception e)
                        {
                            dbContextTransaction.Rollback();
                            AppendExceptionEventLogToFile(e);
                            result = new FuncResult<T>(default, false, FuncResultCode.Exception, e.ToString());
                        }

                    }
                }
            }
            catch (Exception e)
            {
                AppendExceptionEventLogToFile(e);
                result = new FuncResult<T>(default, false, FuncResultCode.Exception, e.ToString());
            }
            return result;
        }
        protected async Task<T> QueryAsync<T>(Func<ApplicationDbContext, Task<T>> lambda)
        {
            T result = default(T);
            try
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                   // using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            result = await lambda(dbContext);
                            //dbContextTransaction.Commit();
                        }
                        catch (ThreadInterruptedException tie)
                        {
                            throw tie;
                        }
                        catch (Exception e)
                        {
                            //dbContextTransaction.Rollback();
                            AppendExceptionEventLogToFile(e);
                        }
                    }
                }
            }

            catch (Exception e)
            {
                AppendExceptionEventLogToFile(e);
            }
            return result;
        }

        protected T Query<T>(Func<ApplicationDbContext, T> lambda)
        {
            T result = default(T);
            try
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            result = lambda(dbContext);
                            dbContextTransaction.Commit();
                        }
                        catch (ThreadInterruptedException tie)
                        {
                            throw tie;
                        }
                        catch (Exception e)
                        {
                            dbContextTransaction.Rollback();
                            AppendExceptionEventLogToFile(e);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                AppendExceptionEventLogToFile(e);
            }
            return result;
        }

        protected FuncResult<T> Query<T>(Func<ApplicationDbContext, FuncResult<T>> lambda)
        {
            var result = new FuncResult<T>();
            try
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            result = lambda(dbContext);
                            dbContextTransaction.Commit();
                        }
                        catch (ThreadInterruptedException tie)
                        {
                            throw tie;
                        }
                        catch (Exception e)
                        {
                            dbContextTransaction.Rollback();
                            AppendExceptionEventLogToFile(e);
                            result = new FuncResult<T>(default(T), false, FuncResultCode.Exception, e.ToString());
                        }
                    }
                }
            }

            catch (Exception e)
            {
                AppendExceptionEventLogToFile(e);
                result = new FuncResult<T>(default(T), false, FuncResultCode.Exception, e.ToString());
            }
            return result;
        }

        //#region Event Log
        //public virtual async Task<FuncResult<bool>> AddEventLogAsync(EventLogModel log)
        //{
        //    return await QueryAsync(async (dbContext) =>
        //    {
        //        FuncResult<bool> result = new FuncResult<bool>();
        //        var logTypeEntity = await dbContext.EventLogTypes.FirstOrDefaultAsync(x => x.LogTypeId == log.LogTypeId);
        //        if (logTypeEntity != null && logTypeEntity.LoggingIsActive)
        //        {
        //            var entity = Mapper.Map<EventLog>(log);
        //            dbContext.EventLogs.Add(entity);
        //            if (dbContext.SaveChanges() > 0)
        //            {
        //                result = new FuncResult<bool>(true);
        //            }
        //        }
        //        return result;
        //    });
        //}

        //public virtual async Task<FuncResult<bool>> AddEventLogAsync(string logType, string logDetail, int? userId = null, string machineName = null)
        //{
        //    return await QueryAsync((dbContext) =>
        //    {
        //        return AddEventLogAsync(dbContext, logType, logDetail, userId, machineName);
        //    });
        //}

        //public virtual async Task<FuncResult<bool>> AddEventLogAsync(LogType logType, string logDetail, int? userId = null, string machineName = null)
        //{
        //    return await QueryAsync((dbContext) =>
        //    {
        //        return AddEventLogAsync(dbContext, logType.GetAttribute<KeyCodeAttribute>(), logDetail, userId, machineName);
        //    });
        //}

        //protected virtual async Task<FuncResult<bool>> AddEventLogAsync(ApplicationDbContext dbContext, string logType, string logDetail, int? userId = null, string machineName = null)
        //{
        //    FuncResult<bool> result = new FuncResult<bool>();
        //    var logTypeEntity = await dbContext.EventLogTypes.FirstOrDefaultAsync(x => x.LogTypeKey.Equals(logType));
        //    string userName = null;
        //    if (userId != null)
        //    {
        //        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        //        userName = user == null ? null : user.DisplayName;
        //    }

        //    if (logTypeEntity != null && logTypeEntity.LoggingIsActive)
        //    {
        //        var eventLog = new EventLog()
        //        {
        //            LogTypeId = logTypeEntity.LogTypeId,
        //            LogDetail = logDetail,
        //            LogUserId = userId,
        //            LogUserName = userName,
        //            LogMachineName = machineName ?? Environment.MachineName
        //        };
        //        dbContext.EventLogs.Add(eventLog);
        //        if (dbContext.SaveChanges() > 0)
        //        {
        //            result = new FuncResult<bool>(true);
        //        }
        //    }
        //    return result;
        //}

        //public virtual FuncResult<bool> AddEventLog(EventLogModel log)
        //{
        //    return Query((dbContext) =>
        //    {
        //        FuncResult<bool> result = new FuncResult<bool>();
        //        var logTypeEntity = dbContext.EventLogTypes.FirstOrDefault(x => x.LogTypeId == log.LogTypeId);
        //        if (logTypeEntity != null && logTypeEntity.LoggingIsActive)
        //        {
        //            var entity = Mapper.Map<EventLog>(log);
        //            dbContext.EventLogs.Add(entity);
        //            if (dbContext.SaveChanges() > 0)
        //            {
        //                result = new FuncResult<bool>(true);
        //            }
        //        }
        //        return result;
        //    });
        //}
        //public virtual FuncResult<bool> AddEventLog(string logType, string logDetail, int? userId = null, string machineName = null)
        //{
        //    return Query((dbContext) =>
        //    {
        //        return AddEventLog(dbContext, logType, logDetail, userId, machineName);
        //    });
        //}

        //public virtual FuncResult<bool> AddEventLog(LogType logType, string logDetail, int? userId = null, string machineName = null)
        //{
        //    return Query((dbContext) =>
        //    {
        //        return AddEventLog(dbContext, logType.GetAttribute<KeyCodeAttribute>(), logDetail, userId, machineName);
        //    });
        //}
        //protected virtual FuncResult<bool> AddEventLog(ApplicationDbContext dbContext, string logType, string logDetail, int? userId = null, string machineName = null)
        //{
        //    FuncResult<bool> result = new FuncResult<bool>();
        //    var logTypeEntity = dbContext.EventLogTypes.FirstOrDefault(x => x.LogTypeKey.Equals(logType, StringComparison.OrdinalIgnoreCase));
        //    string userName = null;
        //    if (userId != null)
        //    {
        //        var user = dbContext.Users.FirstOrDefault(x => x.Id == userId);
        //        userName = user == null ? null : user.DisplayName;
        //    }
        //    if (logTypeEntity != null && logTypeEntity.LoggingIsActive)
        //    {
        //        var eventLog = new EventLog()
        //        {
        //            LogTypeId = logTypeEntity.LogTypeId,
        //            LogDetail = logDetail,
        //            LogUserId = userId,
        //            LogUserName = userName,
        //            LogMachineName = machineName ?? Environment.MachineName
        //        };
        //        dbContext.EventLogs.Add(eventLog);
        //        if (dbContext.SaveChanges() > 0)
        //        {
        //            result = new FuncResult<bool>(true);
        //        }
        //    }
        //    else
        //    {
        //        result = new FuncResult<bool>(false, false, StatusCode.Exception, string.Format("Log Type: {0} not found or logging is not activated.", logType));
        //    }
        //    return result;
        //}


        //#endregion

        #region txt log
        public void AppendExceptionEventLogToFile(Exception ex)
        {
            //The directory shall be configurable in web.config or app.config
            string logDirectory = string.Empty;// = ConfigurationManager.AppSettings["LogDirectory"];
            if (string.IsNullOrWhiteSpace(logDirectory))
            {
                logDirectory = @"App_Data"; //do not set the key in web.config of web portal, so it will use this one
            }
            logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\" + logDirectory;
            bool exists = true;
            DirectoryInfo di = new DirectoryInfo(logDirectory);
            if (!di.Exists)
            {
                try
                {
                    Directory.CreateDirectory(logDirectory);
                }
                catch
                {
                    exists = false;
                }
            }
            if (exists)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.AppendLine("");
                sb.AppendLine(ex.ToString());
                sb.AppendLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                var logfile = (logDirectory + @"\DbException " + DateTime.Today.ToString("yyyyMM") + ".txt");
                lock (exceptionLogLock)
                {
                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(logfile, true);
                        sw.WriteLine(sb.ToString());
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                }

            }
        }
        public void AppendLogToFile(string log)
        {
            //The directory shall be configurable in appsettings.json
            string logDirectory = new ConfigurationBuilder().Build().GetSection("ApplicationSettings")["LogDirectory"];
            if (string.IsNullOrWhiteSpace(logDirectory))
            {
                logDirectory = @"App_Data"; //do not set the key in web.config of web portal, so it will use this one
            }
            logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\" + logDirectory;
            bool exists = true;
            DirectoryInfo di = new DirectoryInfo(logDirectory);
            if (!di.Exists)
            {
                try
                {
                    Directory.CreateDirectory(logDirectory);
                }
                catch
                {
                    exists = false;
                }
            }
            if (exists)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.AppendLine("");
                sb.AppendLine(log);
                sb.AppendLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                var logfile = (logDirectory + @"\DbException " + DateTime.Today.ToString("yyyyMM") + ".txt");
                lock (exceptionLogLock)
                {
                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(logfile, true);
                        sw.WriteLine(sb.ToString());
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                }

            }
        }

        public void Dispose()
        {
            serviceScope?.Dispose();
        }
        #endregion
    }
}

