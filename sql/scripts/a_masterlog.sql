select 
CONCAT (
'[',COALESCE(`ltimestamp`,'no_time_defined'),']: ',
'user ',COALESCE(uname, 'null'),' ',
case 
    when crudcode = 'C' then (CONCAT(
					'CREATED ', COALESCE(`instance_name`,'')
					))
	when crudcode = 'U' then (CONCAT(
					'UPDATED ',coalesce(`instance_name`,'null'),': field ', COALESCE(`column`,'null'), ' VALUES ', COALESCE(`old`,'null'), ' -> ',  COALESCE(`new`,'null'), '.'
					))
    when crudcode = 'D' then 'DELETED'
    when crudcode = 'A' then 'ARCHIVED'
    end
    
    
    






) as USER_LOGGY from log_action 
left join log_values on log_action.log_id=log_values.log_id
left join loginhistory on loginhistory.session_id = log_action.session_id
left join account on account.accid = loginhistory.uid;