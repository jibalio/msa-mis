import java.util.*;
import java.io.*;
class formatter {
	public static void main(String e[])throws Exception {
		
		String file = "dist.male.first";
		Scanner in = new Scanner (new FileReader(file));
		PrintWriter out = new PrintWriter (file+".txt");
		while (in.hasNext()) {
			try {
				out.println(in.nextLine().split("\\s")[0]);
			System.out.println(">>"+in.nextLine().split("\\s")[0]);
			}
			
			
			catch (java.util.NoSuchElementException ex) {
				System.out.println("Finished!");
				out.close();
				System.exit(0);
				
			}
		}
		System.out.println("Finished!");
		out.close();
		System.exit(0);
		
		
	}
}
