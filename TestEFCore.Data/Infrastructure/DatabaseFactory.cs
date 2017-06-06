using System;
using System.Collections.Generic;
using System.Text;
using ERS.Data.ERSContext;

namespace ERS.Data.Infrastructure
{
    public class DatabaseFactory : IDisposable
    {
        private CategoryContext _cataContext;
        public CategoryContext Get()
        {
            return this._cataContext ?? (this._cataContext = new CategoryContext());
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _isDisposed;
        private void Dispose(bool disposing)
        {
            if (!this._isDisposed && disposing)
            {
                if (this._cataContext != null)
                {
                    this._cataContext.Dispose();
                }
            }
            this._isDisposed = true;
        }

        ~DatabaseFactory()
        {
            this.Dispose(false);
        }
    }
}
