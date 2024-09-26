string[] aaaa = new string[63];
Array.Fill(aaaa, "a");

Chess_Library.ChessBot Bot = new Chess_Library.ChessBot(aaaa,false);

/*if (Bot.Move("a4"))
{
    Console.WriteLine("Move was successful");
}
else
{
    Console.WriteLine("Move was not successful");
}*/
string b = "a2";
if (b[2] > 1)
{
    Console.WriteLine("Move was successful");
}