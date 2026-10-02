using ExampleCAdvantage
using System.Runtime.ConstrainedExecution;
List<int> listSo = [6, 9, 5, 7, 8, 3, 1, 2, 4];
List<int> chan = new List<int>();
List<int> le = new List<int>();
//declarative programming

chan = listSo.Where(s=>s%2==0).ToList();
var re = listSo.Select(n => n * n);





le=listSo.Where(s=>s%2!=0).ToList();
//imprerative progamming
for (int i=0; i < listSo.Count; i++)
{
    if (listSo[i] % 2 == 0)
    {
        chan.Add(listSo[i]);
    }
    else
    {
        le.Add(listSo[i]);
    }
}