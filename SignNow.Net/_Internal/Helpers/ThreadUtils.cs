using System;
using System.Threading.Tasks;
using System.Threading;

namespace SignNow.Net._Internal.Helpers
{
    public static class ThreadUtils
    {
        private static readonly TaskFactory TaskFactory = new TaskFactory
                        (CancellationToken.None,
                        TaskCreationOptions.None,
                        TaskContinuationOptions.None,
                        TaskScheduler.Default);

        public static T RunSync<T>(Func<Task<T>> function)
        {
            return TaskFactory
                            .StartNew(function)
                            .Unwrap()
                            .GetAwaiter()
                            .GetResult();
        }

        public static void RunSync(Func<Task> function)
        {
            TaskFactory
                    .StartNew(function)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }
    }
}
