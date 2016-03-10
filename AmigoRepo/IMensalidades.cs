﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoRepo
{
    public interface IMensalidades:IRepositorio, IObservacao
    {
        IPessoa Socio { get; set; }
        IEnumerable<IMesMensalidade> Pagamentos { get; set; }
    }
}
