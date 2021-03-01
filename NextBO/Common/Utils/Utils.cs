namespace NextBO.Wpf
{
    public static class Logger {
        public static void Log(string message) {
#if !DXCORE3
            Xpf.DemoBase.Helpers.Logger.Log(message);
#endif
        }
    }
}

