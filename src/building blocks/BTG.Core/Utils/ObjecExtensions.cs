using System.Threading.Tasks;

namespace BTG.Core.Utils
{
    public static class ObjecExtensions
    {
        public static bool IsNull(this object obj)
        {
            var result = obj is null;
            return result;
        }

        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }

        public static async Task<bool> IsNullAsync(this object obj)
        {
            return await Task.FromResult(obj.IsNull());
        }
    }
}
