﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    interface IView
    {
        void Show();
        void Next();
        void Previous();
    }
}