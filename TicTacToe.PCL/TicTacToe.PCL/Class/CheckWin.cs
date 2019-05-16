using Android.Widget;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.PCL
{
    public static class CheckWin
    {
        public static string Win(List<Button> l1, List<Button> l2, List<Button> l3)
        {
            string player = "x";

            for (int i = 0; i < 2; i++)
            {
                //---
                if (l1.Where(o => o.Text.ToLower() == player).Count() == 3)
                    return player;

                if (l2.Where(o => o.Text.ToLower() == player).Count() == 3)
                    return player;

                if (l3.Where(o => o.Text.ToLower() == player).Count() == 3)
                    return player;

                // / and \
                if (l1[0].Text.ToLower() == player && l2[1].Text.ToLower() == player && l3[2].Text.ToLower() == player)
                    return player;

                if (l1[2].Text.ToLower() == player && l2[1].Text.ToLower() == player && l3[0].Text.ToLower() == player)
                    return player;

                int j = 0;

                // | | |
                foreach (var item in l1)
                {
                    if (item.Text.ToLower() == player && l2[j].Text.ToLower() == player && l3[j].Text.ToLower() == player)
                        return player;

                    j++;
                }

                player = "o";
            }

            return "all";
        }
    }
}