using hl_practicando;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml;



var lista = new List<int>() { 1,2,3,4,5,6,12,2,2,2};



Action<int> criba2 = Criba2;

lista.ForEach(x => Console.WriteLine(x += 1));
lista.ForEach(criba2);

void Criba2(int a) {if (a == 2) Console.WriteLine("tres"); }

