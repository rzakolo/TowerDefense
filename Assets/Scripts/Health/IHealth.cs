﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IHealth
{
    public event Action<int> OnHealthChanged;
}

