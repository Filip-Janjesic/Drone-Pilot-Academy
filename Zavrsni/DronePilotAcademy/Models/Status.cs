using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePilotAcademy.Models.Base;

namespace DronePilotAcademy.Models
{
    public class Status : Entity
    {
        public string Description { get; set; }
    }
}
/*
 * ('ENROLLED'),
	('LISTENING TR'),
	('WAITING ON TR EXAM'),
	('LISTENING FA'),
	('WAITING FA EXAM'),
	('WAITING PL'),
	('PILOTING LESSONS'),
	('WAITING PL EXAM'),
	('DISMISSED');
 */
