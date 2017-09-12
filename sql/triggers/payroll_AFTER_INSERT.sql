CREATE DEFINER=`root`@`localhost` TRIGGER `msadb`.`payroll_AFTER_INSERT` AFTER INSERT ON `payroll` FOR EACH ROW
BEGIN

		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 1, NOW(), NEW.cashbond);


		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 2, NOW(), NEW.cola);


		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 3, NOW(), NEW.cola); 

		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 4, NOW(), NEW.cashadv);	


		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 5, NOW(), NEW.emergencyallowance);    
END