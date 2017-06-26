select did, concat (ti_hh,':',ti_mm,' ',ti_period) as TimeIn,
concat (to_hh,':',to_mm,' ',to_period) as TimeOut,
'days_columnMTWThFSSu' as days from 
/*Override this in GetDays().toString();*/
dutydetails;