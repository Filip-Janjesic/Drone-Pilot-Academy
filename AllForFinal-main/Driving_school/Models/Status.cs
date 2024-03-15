using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models.Base;

namespace DrivingSchool.Models
{	
	public class Status : Entity
	{        
        public string Description {get; set;}
    }
}
/*
 * ('ENROLLED'),
	('LISTENING TR'),
	('WAITING ON TR EXAM'),
	('LISTENING FA'),
	('WAITING FA EXAM'),
	('WAITING DL'),
	('DRIVING LESSONS'),
	('WAITING DL EXAM'),
	('WAITING HAK'),
	('DISMISSED');
 */
