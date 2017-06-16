import java.util.*;
import java.io.*;
import java.util.concurrent.ThreadLocalRandom;
class populator {
	
	/*public static String[][] cities = new String[7][];
	cities[0] = {"Compostella Valley","Laak","Mabini","Maco"," 	Maragusan","Mawab","Monkayo","Montevista","Nabunturan","New Bataan","Pantukan"};
	cities[1] = {"Cotabato","Alamada","Aleosan","Antipas","Arakan","Banisilan","Carmen","Kabacan","Kidapawan","Libungan","M'lang","Magpet","Makilala","Matalam","Midsayap","Pigcawayan","Pikit","President Roxas","Tulunan"};
	cities[3] = {"Davao del Norte", "Braulio E. Dujali","Carmen","Kapalong","New Corella","Panabo","Samal","San Isidro","Santo Tomas","Tagum","Talaingod"};
	cities[4] = {"Davao del Sur","Bansalan","Davao City","Digos","Hagonoy","Kiblawan","Magsaysay","Malalag","Matanao","Padada","Santa Cruz","Sulop"};	
	cities[5] = {"Davao Occidental","Don Marcelino","Jose Abad Santos (Trinidad)","Malita","Santa Maria","Sarangani"};	
	cities[6] = {"Davao del Sur","Bansalan","Davao City","Digos","Hagonoy","Kiblawan","Magsaysay","Malalag","Matanao","Padada","Santa Cruz","Sulop"};	
	cities[7] = {"Davao del Sur","Bansalan","Davao City","Digos","Hagonoy","Kiblawan","Magsaysay","Malalag","Matanao","Padada","Santa Cruz","Sulop"};	
	cities[8] = {"Davao del Sur","Bansalan","Davao City","Digos","Hagonoy","Kiblawan","Magsaysay","Malalag","Matanao","Padada","Santa Cruz","Sulop"};	
	cities[9] = {"Davao del Sur","Bansalan","Davao City","Digos","Hagonoy","Kiblawan","Magsaysay","Malalag","Matanao","Padada","Santa Cruz","Sulop"};	*/
	final static int ln = 0, m=2, f=1, comp=3;
	static String files[] = {"dist.all.last.txt","dist.female.first.txt","dist.male.first.txt","companies.txt"};
		static int bytes[] = {44400,2138,610,947};
		static ArrayList<ArrayList<String>> map = new ArrayList<ArrayList<String>>();
		static PrintWriter out; 
	public static void main(String e[])throws Exception {
			init();
			
			generateDep(3,293);
		
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
