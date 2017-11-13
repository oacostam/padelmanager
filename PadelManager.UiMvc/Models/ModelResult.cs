#region

using System;

#endregion

namespace PadelManager.UiMvc.Models
{
    [Serializable]
    public class ModelResult<T> where T : class
    {
        public ModelResult(T result, int total = 0, string error = null)
        {
            Result = result;
            Total = total;
            Error = error;
        }

        public string Error { get; }

        public int Total { get; }

        public T Result { get; }
    }
}