using System.Text;

namespace knightsTour{
  class Program{

    static int boardSize = 8;

    //Possible moves by index
    static int[] xmove = {2, 2, 1, 1, -1, -1, -2, -2};
    static int[] ymove = {1, -1, 2, -2, 2, -2, 1, -1};

    //Board initializaton
    // static int[,] board = new int[boardSize,boardSize];
    static int[,] board = new int[boardSize, boardSize];

    static StringBuilder sb = new StringBuilder();
    static String? move;

    public static void Main(string[] args)
    {
      //Starting position
      board[2, 3] = 1;
      printBoard(board, boardSize);
      if (solve(board, 2, 3, boardSize, 1))
      {
        printBoard(board, boardSize);
        Console.WriteLine(sb + "Done.");
      }
    }

    public static void printBoard(int[,] board, int boardSize){
      for(int i = 0; i<boardSize; i++)
      {
        for(int j=0; j<boardSize; j++) Console.Write("{0:00}   ", board[i,j]);
        Console.WriteLine();
      }
        Console.WriteLine("---------------------------");
    }


    static public bool solve(int[,] board, int x, int y, int boardSize, int cnt)
    {
      //for each possible move of the knight 
      for (int i=0; i<8; i++)
      {
        if(cnt>=64) return true;
        else
        {
          int newx = x + xmove[i];
          int newy = y + ymove[i];
          if (isValidMove(board, newx, newy))
          {
            board[newx, newy] = cnt+1;
            move = $"({x},{y})->({newx},{newy})  =>  ";
            sb.Append(move);
            if (solve(board, newx, newy, boardSize, cnt+1))
            {
              return true;
            }
            sb.Remove(sb.Length-move.Length, move.Length);
            board[newx, newy] = 0;
          }
        }
      }
      return false;
    }

    static public bool isValidMove(int[,] board, int x, int y)
    {
      return x<boardSize && x>=0 && y<boardSize && y>=0 && board[x, y] == 0;
    }

  }
}
