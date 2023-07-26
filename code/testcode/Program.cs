			string noidung = "Ghi file C# khong kho +3";
            string nd2 = Console.ReadLine();
            noidung = noidung + " " + nd2;
			File.WriteAllText("out.txt", noidung);

			string a = File.ReadAllText("out.txt");
			Console.WriteLine(a);

			Console.ReadKey(); // stop screen

			Console.WriteLine("╔═╗┬─┐┌─┐┌─┐┌┬┐┌─┐  ┌┐┌┌─┐┬ ┬  ┌─┐┬─┐┌┬┐┌─┐┬─┐\n ║  ├┬┘├┤ ├─┤ │ ├┤   │││├┤ │││  │ │├┬┘ ││├┤ ├┬┘\n ╚═╝┴└─└─┘┴ ┴ ┴ └─┘  ┘└┘└─┘└┴┘  └─┘┴└──┴┘└─┘┴└─");