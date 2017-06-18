# MSA-MIS
An information system for Makabayan Security Agency.

## Modules
* Guard and Client Management Module
* Duty Scheduling Module
* Payroll Module

## Requirements
MySql. Database files can be found [here](https://github.com/lerycibalio/msa-mis/tree/master/sql).

## Docs

`

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

`


