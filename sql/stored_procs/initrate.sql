CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_basicpay`()
BEGIN
	SET @cw = (select count(*) from basicpay where start<NOW() and `end`>NOW());
	UPDATE msadb.basicpay
	set status = (case 	when (status=1 and (@cw)>1) then 0 
						when (status=2 and (@cw)>1) then 1 end)
	where start<NOW() and `end`>NOW();
END