﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCodeFirst.Models
{
	public class CalculoNomina
	{

		public int id { get; set; }
        public DateTime FechaNomina { get; set; }
		public Nullable<decimal> MontoTotal { get; set; }

	}
}