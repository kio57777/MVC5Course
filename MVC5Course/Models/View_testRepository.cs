using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class View_testRepository : EFRepository<View_test>, IView_testRepository
	{

	}

	public  interface IView_testRepository : IRepository<View_test>
	{

	}
}