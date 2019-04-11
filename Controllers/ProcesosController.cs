using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalCodeFirst.Models;
namespace PruebaFinal2019.Controllers
{
    public class ProcesosController : Controller
    {

		Contexto BD = new Contexto();


		// *****************************************************************
		//                   Modulo de Procesos
		// ******************************************************************



		public ActionResult CalculoNomina()
		{

			//ViewBag.TotalSalario = BD.Empleados.Sum(a => a.Salario); // suma los salarios
			
			var query = from activos in BD.Empleados
								   where activos.Estado == "Activo"
								   select activos;

			ViewBag.Nomina = query.Sum(activos => activos.Salario);

			BD.SaveChanges();
			return View();

		}

		[HttpPost]
		public ActionResult CalculoNomina(CalculoNomina CN)
		{

			var query = from activos in BD.Empleados
						where activos.Estado == "Activo"
						select activos;
           

			var Nomina = query.Sum(activos => activos.Salario);
			CN.MontoTotal = Nomina;
			BD.CalculoNominas.Add(CN);
			BD.SaveChanges();

			return RedirectToAction("Enviado","Mantenimiento","Home");
		}

		
		public ActionResult SalidaEmpleado(Empleado emp)
		{
			//****************************************************************************
			//                   Querys para llenar el DropdownList
			//*****************************************************************************
		


			var query1 = from a in BD.Empleados
						select a.NombreEmpleado;

			var empleados = query1.ToList();

			
			var listaEmpleados = new SelectList(empleados, "NombreEmpleado");
			ViewBag.Empleados = listaEmpleados;

		

			BD.SaveChanges();
			return View();
		}
		[HttpPost]
		public ActionResult SalidaEmpleado(SalidaEmpleado salida, String DropDownList)
		{
			//****************************************************************************
			//                   Querys Inactivo 
			//*****************************************************************************


			var query4 = (from a in BD.Empleados
						  where a.NombreEmpleado == DropDownList
						  select a).First();

			var query2 = (from a in BD.Empleados
						  where a.NombreEmpleado == DropDownList
						  select a.NombreEmpleado).First();

			if (query4 != null)
			{
				query4.Estado = "Inactivo";
				salida.Empleado = query2.ToString();
			}


			BD.SalidaEmpleados.Add(salida);
			BD.SaveChanges();
			return RedirectToAction("Enviado", "Mantenimiento", "Home");
		}
	
		public ActionResult Vacaciones()
		{

			//****************************************************************************
			//                   Querys para llenar el DropdownList
			//*****************************************************************************

			var query1 = from a in BD.Empleados
						 select a.NombreEmpleado;

			var empleados = query1.ToList();

			var listaEmpleados = new SelectList(empleados, "NombreEmpleado");
			ViewBag.Empleados = listaEmpleados;

			BD.SaveChanges();
			return View();

		}

		[HttpPost]
		public ActionResult Vacaciones(Vacaciones vaca,String DropDownList)
		{
			var query4 = (from a in BD.Empleados
						  where a.NombreEmpleado == DropDownList
						  select a).First();


			//var query2 = (from a in BD.vacaciones
			//			  where a.Empleado == DropDownList
			//			  select a.Empleado);

			vaca.Empleado = query4.ToString();

			BD.vacaciones.Add(vaca);
			BD.SaveChanges();
			return RedirectToAction("Enviado", "Mantenimiento", "Home");

		}


		public ActionResult Permisos()
		{

			//****************************************************************************
			//                   Querys para llenar el DropdownList
			//*****************************************************************************

			var query1 = from a in BD.Empleados
						 select a.NombreEmpleado;

			var empleados = query1.ToList();

			var listaEmpleados = new SelectList(empleados, "NombreEmpleado");
			ViewBag.Empleados = listaEmpleados;
		
		
			return View();

		}

		
		[HttpPost]
		public ActionResult Permisos(Permiso permi, String DropDownList)
		{

			//var query4 = (from a in BD.Permisos
			//			  where a.Empleado == DropDownList
			//			  select a).First();

			var query2 = (from a in BD.Empleados
						  where a.NombreEmpleado == DropDownList
						  select a.NombreEmpleado).First();


			permi.Empleado = query2.ToString();

			BD.Permisos.Add(permi);
			BD.SaveChanges();
			return RedirectToAction("Enviado", "Mantenimiento", "Home");

		}


	
		public ActionResult Licencias()
		{

			//****************************************************************************
			//                   Querys para llenar el DropdownList
			//*****************************************************************************

			var query1 = from a in BD.Empleados
						 select a.NombreEmpleado;

			var empleados = query1.ToList();

			var listaEmpleados = new SelectList(empleados, "NombreEmpleado");
			ViewBag.Empleados = listaEmpleados;

			return View();

		}
		[HttpPost]
		public ActionResult Licencias(Licencia licen, String DropDownList)
		{

			var query4 = (from a in BD.Licencias
						  where a.Empleado == DropDownList
						  select a).First();


			var query2 = (from a in BD.Licencias
						  where a.Empleado == DropDownList
						  select a.Empleado);

			licen.Empleado = query2.ToString();

			BD.Licencias.Add(licen);
			BD.SaveChanges();
			return RedirectToAction("Enviado", "Mantenimiento", "Home");
		}

	}

}
