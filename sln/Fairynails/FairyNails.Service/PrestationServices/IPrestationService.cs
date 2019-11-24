﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace FairyNails.Service.PrestationServices
{
    /// <summary>
    /// A CSInterface definition.
    /// </summary>
    public interface IPrestationService
    {
        #region properties

        #endregion

        #region methods
        public List<T> GetAllPrestations<T>() where T : IPrestation, new();
        #endregion
    }
}