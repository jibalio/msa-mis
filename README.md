# MSA-MIS
An information system for Makabayan Security Agency written in C# &#x1F499;&#x1F499;&#x1F499;



## Installation
### Prerequisite Packages
MSA-MIS requires [MySql.Data 6.9.9](https://www.nuget.org/packages/MySql.Data/6.9.9) and [MySqlBackup.NET 2.0.9.2](https://www.nuget.org/packages/MySqlBackup.NET/2.0.9.2) to run. **Note: These packages should install automatically** *(Internet Connection Required)*. If automatic installation fails, these packages can be installed using the NuGet Package Manager.

Go to `Tools > NuGet Package Manager > Package Manager Console`
```
PM > Get-Project -All | Install-Package MySql.Data -version 6.9.9
PM > Get-Project -ryldb.sqltools | Install-Package MySqlBackup.NET -Version 2.0.9.2
PM> Get-Project ryldb.sqltools | Install-Package Microsoft.Office.Interop.Excel
PM> Get-Project ryldb.sqltools | Install-Package BCrypt.Net-Next -Version 2.1.1
```

### Database 
**The program automatically imports the database**. If this fails, download the SQL Dump [here](https://github.com/lerycibalio/msa-mis/tree/master/sql) and manually import to databases `msadb` and `msadbarchive`.

### Software
~~**Backend:** Export the database dump **using MySQL Workbench 6.3.8+ only**. Using older versions will cause MSA-MIS's auto-database-import component `(AutoLoader.cs)` to fail. *Ayaw gamita ang sql workbench sa F610 kay mabungkag ang AutoLoader.cs, kara-an kaayo*.~~
Nvm ok na.

**Important (MySql Workbench 6.3+ only)**: Turn on  'Include Create Schema' in export settings. 

## About
### Modules
* Guard and Client Management Module
* Duty Scheduling Module
* Payroll Module

![](sss-contribution-table-2017.png)
![](revised-withholding-tax-tables.jpg)

<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
**U shouldn't be in here, go scroll back up.**

## Docs

```
/*GENERIC METHODS
* ExecuteQuery(query)      :   DataTable
         * ExecuteReader(query)     :   MySqlDataReader
         * ExecuteNonQuery(query)   :   void
         * ExecuteSingleResult(query)  :   String
         * ExecuteQuery (String query)
         * ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword)
         * ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword, String orderby)
         * ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         */

        /*
         *  HOW TO USE ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         *  
         *  Package:    ryldb.sqltools
         *  Class:      SQLTools
         *  Method:     ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         *  
         *  @return DataTable with specified filters applied
         *  @param query:     Base query
         *                   e.g. select * from clients
         *  @param ColumnToFilterByKeyword:    column to sortby
         *                  e.g. AssignmentID
         *  @param keyword: filter column with keyword
         *  @param orderby:  format:  "<ColumnToSort> <ASC/DESC>"
         *  
         *  @param filters[]: THE TRICKY PART: pay close attention boi 👀👀
         *  In order for this to work, query must be formatted such that it is compatible with
         *  C#'s String.format(). 
         *  TL;DR: Use placeholders {0} {1} .... {n}
         *  Example: 
         *      select * from guards where lastname='{0}' and firstname='{1}'
         *  then, in the filters[] parameter, create a string array containing the corresponding placeholder values.
         *  
         *  Example usage:
         *  String q = "select ln, fn, mn from guards where status={0} and birthyear={1}";
         *  ryldb.sqltools.SqlTools.ExecuteQuery( q, "ln", "Regodon", "ln asc", new String ("Active", "1998");
         * 
         * 
         *  OTHER VARIANTS THO
         *  ExecuteQuery (String query)
         *  ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword)
         *  ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword, String orderby)
         *  ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         */

```


