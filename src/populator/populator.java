import java.util.*;
import java.io.*;
import java.util.concurrent.ThreadLocalRandom;
class populator {
	
	public static String[][] cities = new String[7][];
	
	static String[] st = {"M. de Santos St.","A. Soriano Ave.","Fidel A. Reyes St.","Raja Matanda St.","M. V. de los Santos St.","Legarda St.","F. Torres St.","Alfonso Mendoza St.","Juan Luna St.","Engracia C. Reyes St.","Teodora Alonzo St.","A. J. Villegas St.","Jose Laurel St.","Recto Ave.","Padre Burgos Ave.","G. Tuazon St.","F. Varona St.","A. Bautista St.","A. Lorenzo Jr. St.","Victorino Mapa St.","J. Figueras St.","Josefa Llanes Escoda St.","Herrera St.","President Quirino Ave. Ext.","Madre Ignacia St.","G. M. Tolentino St.","Rizal Ave.","Antonio C. Delgado St.","Felipe Agoncillo St.","Natividad Almeda Lopez St.","Norberto Ty St.","R. Cristobal, Sr. St.","F. Torres St.","Adriatico St.","Angel Linao St.","Burke St.","Benavidez St.","Valderama St.","Asuncion St. ","Roxas Bridge","Salas St.","Rizal Ave.","Carlos Palanca, Sr. St.","Vicente G. Cruz St.","Quezon Boulevard","M. Natividad St.","Maria Y. Orosa St.","Carmen Planas St.","Sabino Padilla St.","Arquiza St.","Gen. Geronimo St.","F. Dalupan St.","Luis Maria Guerrero St.","Sta. Teresita St.","Pedro Gil St.","Pilar Hidalgo Lim St.","Dr. M. L. Carreon St.","United Nations Ave.","F. Cayco St.","F. T. Benitez St.","S. H. Loyola St.","M. F. Jhocson St.","Carmen St.","Quirino Ave. ","G. Masangkay St.","Bonifacio Dr.","P. Guevarra St.","Abad Santos Ave.","Guerrero St.","D. Romualdez, Sr. St.","Doroteo Jose St.","De Guzman St.","J. Quintos, Sr. St.","Tomas Mapua St.","Tayuman St.","Nicanor Reyes St.","Jorge Bocobo St.","Kusang Loob St.","P. Paterno St.","Nicanor Padilla St.","Gen. Luna St.","E. T. Yuchengco St.","A. Mabini St.","Severino St.","Padre Faura St.","G. Apacible St.","V. Tytana St.","Maria Paz Mendoza Guazon St.","Leon Guinto St.","J. Marzan St.","Mahatma Gandhi St.","Santo Cristo St. Ext.","Pitong Gatang St.","Del Pan St.","Sales St.","Gonzalo Puyat St.","Del Pilar St.","General Luna St.","Real St.","Quezon Boulevard","E. Remigio St.","Quintin Paredes St.","Ongpin St.","Elcano St.","Arlegui St.","Tomas Pinpin St.","Alhambra St.","Legazpi St. ","Kalaw Ave.","Evangelista St.","P. Gomez St.","R. Hidalgo St.","N. Zamora St.","Blumentritt Rd.","Salcepuedes St.","Urbiztondo St.","Santo Cristo St.","J. Nepomuceno St.","Francis P. Yuseco St.","Gen. M. Malvar St.","S. Reyes St.","M. Dela Fuente St.","Bambang St.","Dr. Concepcion C. Aguila St.","F. M. Gernale St.","Julio Nakpil St.","Pablo Ocampo St.","A. Maceda St.","Antonio Vasquez St.","Valeriano Fugoso St.","Gen. Luna St.","Taft Ave.","Roxas Boulevard","Lacson Ave.","Quirino Ave.","Juan N. Luna St.","Parade Ave.","Honorio Lopez Boulevard","Old Panaderos St.","Legarda St.","Magsaysay Boulevard","Old Santa Mesa Rd.","Macario Asistio, Sr. Ave.","L. P. Leviste St.","Carlos Palanca St.","J. Escriva Dr.","P. Bernardo St.","Monte de Piedad St.","N. Domingo St.","Ignacio S. Diaz St.","Batasan-San Mateo Rd.","University Ave.","Sgt. Esguerra Ave.","T. Arguelles St.","Dona Juana S. Rodriguez Ave.","Gil Puyat Ave.","Zamora St.","Arnaiz Ave.","Domingo M. Guevara St.","Edang St.","Diego Cera Ave. ","Nicanor Garcia St.","N. S. Amoranto St.","Jose Gil St.","Danny Floro St.","Mother Ignacia St.","Erano Manalo Ave.","P. Tuazon Boulevard","A. Layug St.","Batasan Rd.","M. Vicente St.","Sacred Heart St.","Commonwealth Ave.","ADB Ave.","Holy Spirit Dr.","C. P. Garcia Ave.","M. L. Quezon","Elisco Rd.","F. Ortigas, Jr. Rd.","E. Rodriguez Sr. Ave.","E. Quirino Ave.","P. Binay St.","Capitol Hills Dr. ","Dr. Jose P. Rizal Ext.","V. A. Rufino St.","Rizal Ave. Ext.","Dr. Sixto Antonio Ave.","Sumulong Highway","Epifanio de los Santos Ave.","Lieutenant Artiaga St.","Quirino Highway","Kalayaan Ave.","Luis Shiangho St.","T. Gener St.","Judge Jimenez St.","C. P. Garcia Ave.","Sta. Catalina St.","Nicanor Roxas St.","Payatas Rd.","Justice Lourdes Paredes San Diego Ave.","Don M. Agregado","Mapagkawanggawa St.","MacArthur Highway","Aurora Boulevard","Taft Ave. Ext.","NAIA Rd.","V. Luna Ave.","Mindanao Ave.","Ermin Garcia Ave.","Scout Oscar M. Alcaraz St.","Pablo P. Reyes, Sr. St.","F. Manalo St.","Andrews Ave. and Lawton Ave.","Osmena Ave.","North Luzon Expressway","Arnaiz Ave.","Chino Roces Ave.","C. P. Garcia Ave.","Sen. Mariano J. Cuenco St.","Dona M. Hemady St.","N. Ramirez St.","Quezon Ave.","Thailand St.","Tomas Morato Ave.","Old Samson Rd.","P. de la Cruz St.","Col. Bonny Serrano Ave.","Don J. Gregorio St.","Speaker Perez St.","Roxas Ave.","Timog Ave.","Eugenio Lopez St.","Scout Bayoran St.","Scout Borromeo St.","Scout Madrinan St.","Scout Rallos St.","Scout Limbaga St.","Scout Fernandez St.","Scout Fuentebella St.","Scout Gandia St.","Scout de Guia St.","Dr. Lazcano St.","Scout Delgado St.","Scout Lozano St.","Scout Castor St.","Marathon St.","Fr. Martinez St.","Scout Ojeda St.","Scout Chuatoco St.","Scout Magbanua St.","Scout Reyes St.","Scout Santiago St.","Scout Tobias St.","Scout Tuason St.","Scout Torillo St.","Scout Ybardolaza St.","11th Jamboree St.","Scout Rallos Ext.","South Luzon Expressway","Don Alejandro Roces Ave.","Hunters ROTC Ave.","Dr. Santos Ave.","Eymard Dr.","Comm. Dev. Center St.","Sgt. E. Rivera St.","N. Zamora St.","Aurora Boulevard","Familara St.","Betty Go-Belmonte St.","Sgt. J. Catolos","Quirino Ave.","Temple Dr."};
	static String[] brgy = {"Daang Bakal","Daanghari","Dagat-Dagatan","Dalandanan","Damar","Damayang Lagi","Dampalit","Daniel Fajardo","Dasmarinas","Del Monte","Dela Paz","Deparo","Dioquino Zobel","Don Bosco","Don Carlos Village","Don Galo","Don Manuel","Dona Aurora","Dona Imelda","Dona Josefa","Duyan Duyan","East Kamias","East Rembo","Edang","Elias Aldana","Ermitano","Escopa ","Ermita","E. Rodriguez","Fairview","Francis Burton Harrison","Flores","Forbes Park","Fort Bonifacio","Fortune","Gagalangin","General T. de Leon","Grace Park East","Grace Park West","Greater Lagro","Greenhills","Guadalupe Nuevo","Guadalupe Viejo","Gulod","Hagdan Bato Itaas","Hagdan Bato Libis","Hagonoy","Harapin ang Bukas","Heroes del 96","Highway Hills","Horseshoe","Holy Spirit","Hulo","Hulong Duhat","Kabayanan","Kalawaan","Kalayaan","Kaligayahan","Kalusugan","Kamuning","Kapasigan","Kapitolyo","Karuhatan","Kasilawan","Katipunan","Katuparan","Kaunlaran","Kaunlaran Village","Kristong Hari","Krus na Ligas","La Huerta","La Paz","Laging Handa","Lawang Bato","Layug","Leveriza","Libertad","Libis","Libis Baesa","Libis Reparo","Ligid Tipas","Lingunan","Little Baguio","Llano","Longos","Lourdes","Lower Bicutan","Loyola Heights","M. Dela Cruz","Malaria","Mabini-J. Rizal","Mabolo","Magallanes","Magtanggol","Maharlika","Maharlika Village","Makati","Malamig","Malanday","Malanday","Malate","Malaya","Malibay","Malinao","Malinta","Mandaluyong","Mangga","Manggahan","Manila Bay Reclamation","Manresa","Manuyo Uno","Manuyo Dos","Mapulang Lupa","Marcelo Green","Mariana","Mariblo","Maricaban","Marikina Heights","Marilag","Martires","Marulas","Marulas","Masagana","Masambong","Matandang Balara","Mauway","Maybunga","Maypajo","Maysan","Maysilo","Maytunas","Merville","Milagrosa","Monumento","Moonwalk","Morning Breeze","Muntinlupa","Munoz","Muzon"};
	static String[] city = {"Compostela City","Laak City","Mabini City","Maco City","Maragusan City","Mawab City","Monkayo City","Montevista City","Nabunturan City","New Bataan City","Pantukan City","Alamada City","Aleosan City","Antipas City","Arakan City","Banisilan City","Carmen City","Kabacan City","Kidapawan City","Libungan City","M'lang City","Magpet City","Makilala City","Matalam City","Midsayap City","Pigcawayan City","Pikit City","President Roxas City","Tulunan City","Asuncion City","Braulio E. Dujali City","Carmen City","Kapalong City","New Corella City","Panabo City","Samal City","San Isidro City","Santo Tomas City","Tagum City","Talaingod City","Bansalan City","Davao City City","Digos City","Hagonoy City","Kiblawan City","Magsaysay City","Malalag City","Matanao City","Padada City","Santa Cruz City","Sulop City","Don Marcelino City","Jose Abad Santos City","Malita City","Santa Maria City","Sarangani City","Baganga City","Banaybanay City","Boston City","Caraga City","Cateel City","Governor Generoso City","Lupon City","Manay City","Mati City","San Isidro City","Tarragona City","Basilisa City","Cagdianao City","Dinagat City","San Jose City","Tubajon City","Arteche City","Balangiga City","Balangkayan City","Borongan City","Can-avid City","Dolores City","General MacArthur City","Giporlos City","Guiuan City","Hernani City","Jipapad City","Lawaan City","Llorente City","Maslog City","Maydolong City","Mercedes City","Oras City","Quinapondan City","Salcedo City","San Julian City","San Policarpo City","Sulat City","Taft City","Buenavista City","Jordan City","Nueva Valencia City","San Lorenzo City","Sibunag City","Aguinaldo City","Alfonso Lista City","Asipulo City","Banaue City","Hingyon City","Hungduan City","Kiangan City","Lagawe City","Lamut City","Mayoyao City","Tinoc City","Adams City","Bacarra City","Badoc City","Bangui City","Banna City","Batac City","Burgos City","Carasi City","Currimao City","Dingras City","Dumalneg City","Laoag City","Marcos City","Nueva Era City","Pagudpud City","Paoay City","Pasuquin City","Piddig City","Pinili City","San Nicolas City","Sarrat City","Solsona City","Vintar City","Alilem City","Banayoyo City","Bantay City","Burgos City","Cabugao City","Candon City","Caoayan City","Cervantes City","Galimuyod City","Gregorio del Pilar City","Lidlidda City","Magsingal City","Nagbukel City","Narvacan City","Quirino City","Salcedo City","San Emilio City","San Esteban City","San Ildefonso City","San Juan City","San Vicente City","Santa City","Santa Catalina City","Santa Cruz City","Santa Lucia City","Santa Maria City","Santiago City","Santo Domingo City","Sigay City","Sinait City","Sugpon City","Suyo City","Tagudin City","Vigan City","Ajuy City","Alimodian City","Anilao City","Davao City","Makati City","General Santos City","Tagum City","Iligan City","Cagayan de Oro City"};
	
	final static int ln = 0, m=2, f=1, comp=3;
	static String files[] = {"dist.all.last.txt","dist.female.first.txt","dist.male.first.txt","companies.txt"};
		static int bytes[] = {44400,2138,610,947};
		static ArrayList<ArrayList<String>> map = new ArrayList<ArrayList<String>>();
		static PrintWriter out; 
	public static void main(String e[])throws Exception {
			init();
			
			//generateDep(3,293);
			generateClients(200);
		}
		
		
	public static void generateClients(int c) {
		for(int d=0;d<200;d++) {
			String compx = map.get(comp).get(rng(1,bytes[comp]-2)).replace("'","\\'");
			out.printf("INSERT INTO `msadb`.`client` (`Name`, `ClientStreetNo`, `ClientStreet`, `ClientBrgy`, `ClientCity`, `ContactPerson`, `ContactNo`, `Manager`, `CStatus`) VALUES "+
			"('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s');\n",
			compx,rng(1,4123)+"",getrandarr(st), getrandarr(brgy),getrandarr(city), getName("ln, fn mn"), (rng(111,999)+""+rng(1111,9999)), getName("ln, fn mn"), "1" );
			
		}
		out.close();
	}
	
	public static String getrandarr(String[] arr) {
		return arr[rng(0,arr.length-1)];
	}
	
	public static void generateDep(int x, int y) {
		for (int c=x; c<=y; c++) {
				
				int rel = rng(1,5);
				
				
				for (int d=0; d<5; d++) {
					String fna ="";
				if (rel==1||rel==4) fna = getfname("f");
				if (rel==2 || rel==3) fna = getfname("m");
				if (rel==5) fna = getfname((rng(1,2)==m?"m":"f"));
					out.printf("INSERT INTO `msadb`.`dependents` (`DRelationship`, `FN`, `MN`, `LN` ,`GID`)  VALUES ('%d', '%s', '%s', '%s', '%d');\n", rel,fna,getmname(),getlname(),c);
					
				}
			}
			System.exit(0);
	}
		
	public static void init() throws Exception{
		out = new PrintWriter("output.sql");
		for (int c=0; c<files.length; c++) {
			Scanner scan = new Scanner (new FileReader(files[c]));
			ArrayList<String> arr = new ArrayList<String>();
			System.out.println("Loading "+files[c]);
			long no = 0;
			while (scan.hasNext()) {
				no++;
				arr.add(scan.nextLine());
			}
			if (no==bytes[c])System.out.println("Successfully loaded "+no+" names from "+files[c]);
			else System.out.println ("Error: Incomplete Values");
			map.add(c,arr);
		}
		System.out.println("-----------------------------------------------------------------");
		
	}	
		
	public static void PrintGuard() throws Exception {
		
		System.out.println(map.get(0).size());
		// Start Actual values.
		
		
		PrintWriter out = new PrintWriter("output.sql");
		for (int fq=0; fq<1000; fq++) {
			int gender = (int)rng(1,2);
			String fn;
			if (gender==m)
				fn = map.get(m).get(rng_ex(1,bytes[m]-1));
			else fn = map.get(f).get(rng_ex(1,bytes[f]-1));
			String lastname = map.get(ln).get(rng_ex(1,bytes[ln]));
			String middlename = map.get(ln).get(rng_ex(1,bytes[ln]));
				
	
			
			String bdate=rng(1,12)+"/"+rng(1,28)+"/"+rng(1972,1998);
			String Height = rng(5,6) +" " +"11";
			String[] rs = {"Roman Catholic", "Islam", "Protestant"};
			String religion = rs[rng(0,rs.length)];
			int civilstatus = rng(1,2);
			String CelNo = "+63 "+rng(100,999)+" "+rng(100,999)+" "+rng(1111,9999);
			String TelNo = "212-"+rng(1000,9999);
			String LicNo = "09-"+rng(1111111,9999999)+"-"+rng(0,9);
			String SSS = LicNo;
			String TIN = String.format("%d-%d-%d", rng(111,999),rng(111,999),rng(111,999));
			String PhilHealth = String.format("%d-%d-%d", rng(11,99),rng(111111111,999999999),rng(0,9));
			String PrevAss = map.get(comp).get(rng_ex(1,bytes[comp]-1)).replace("'","\\'");
			String EdAtt = rng(2,4)+"";
			String emercontact = tcase(map.get(m).get(rng_ex(1,bytes[m]-1)))+" "+tcase(map.get(ln).get(rng_ex(1,bytes[ln]-1)));
			String emerno = "09"+rng(111111111,999999999);
			String w = String.format("%d kg.", rng(75,120));
				
				
			out.printf("INSERT INTO Guards(FN, MN, LN, GStatus, BDate, Gender, Height, Weight, Religion, CivilStatus, CellNo, TelNo, LicenseNo, SSS, TIN, PhilHealth, PrevAgency, EdAtt, EmergencyContact, EmergencyNo) VALUES"+
			" ('%s','%s','%s','1','%s','%s','%s','%s','%s','%s','%s','%s.','%s','%s','%s','%s','%s','%s','%s','%s');\n",
			
			
			
			
			tcase(fn),tcase(middlename),tcase(lastname),bdate,gender, Height, w,religion, civilstatus,CelNo, TelNo, LicNo, SSS, TIN, PhilHealth, PrevAss,EdAtt,emercontact, emerno);
			
			//out.println("INSERT INTO `msadb`.`guards` (`FN`, `MN`, `LN`, `CivilStatus`, `BDate`, `Gender`, `Religion`, `ContactNo`, `PrevAgency`, `SSS`, `TIN`, `PhilHealth`, `LicenseNo`, `GStatus`, `Height`, `Weight`, `EmergencyNo`) VALUES ('fn', 'mn', 'ln', '1', '1', '1', 'religion', '111111111', 'prevagenct', '555 555 555', '555 555 555', '00-000000000-0', '555 555 555', '1', '1 11', '111kg.', '0912737451');");
			//System.out.println("INSERT INTO `msadb`.`guards` (`FN`, `MN`, `LN`, `CivilStatus`, `BDate`, `Gender`, `Religion`, `ContactNo`, `PrevAgency`, `SSS`, `TIN`, `PhilHealth`, `LicenseNo`, `GStatus`, `Height`, `Weight`, `EmergencyNo`) VALUES ('fn', 'mn', 'ln', '1', '1', '1', 'religion', '111111111', 'prevagenct', '555 555 555', '555 555 555', '00-000000000-0', '555 555 555', '1', '1 11', '111kg.', '0912737451');");
			
	}
		
		
	}
	
	static String tcase (String s) {
		String newx = ""+s.charAt(0);
		newx+=s.substring(1,s.length()).toLowerCase();
		return newx;
		
		
    }

	
	static Random rand = new Random();
	
	public static int rng(int a, int b) {
		return ThreadLocalRandom.current().nextInt(a, b);
	}
	
	//exclusive
	public static int rng_ex(int a, int b) {
		return ThreadLocalRandom.current().nextInt(a, b + 1);
	}
	
	public static String getfname() {
		return getfname("m");
	}
	
	
	
	public static String getfname(String gender) {
		switch (gender) {
			case "m": return  map.get(m).get(rng_ex(1,bytes[m]-1));
			case "f": return map.get(f).get(rng_ex(1,bytes[f]-1));
		}
		return "nofngenerated";
	}
	
	public static String getlname() {
		String x = map.get(ln).get(rng_ex(1,bytes[ln]-2));
		return x;
	}
	public static String getmname() {
		String x =  map.get(ln).get(rng_ex(1,bytes[ln]-2));;;
		return x;
	}
	
	
	public static String getName(String format){
		String f = format;
		f=f.replaceAll("fn",getfname());
		f=f.replaceAll("mn",getmname());
		f=f.replaceAll("ln",getlname());
		System.out.println();
		return f;
	}
	


	
}
