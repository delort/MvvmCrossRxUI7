using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Splat;

namespace MvvmCrossRxUI7.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Locator.CurrentMutable.RegisterConstant(new MyRxLogger { Level = LogLevel.Debug }, typeof(ILogger));
        }
    }

    public class MyRxLogger : ILogger
    {
        public LogLevel Level { get; set; }

        public void Write(string message, LogLevel logLevel)
        {
            if (logLevel < this.Level)
                return;

            Mvx.TaggedTrace(ToLevel(logLevel), "RxLogger", message);
        }

        private static MvxTraceLevel ToLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Info:
                    return MvxTraceLevel.Diagnostic;
                case LogLevel.Warn:
                    return MvxTraceLevel.Warning;
                case LogLevel.Debug:
                    return MvxTraceLevel.Diagnostic;
                default:
                case LogLevel.Error:
                case LogLevel.Fatal:
                    return MvxTraceLevel.Error;
            }
        }
    }
}
