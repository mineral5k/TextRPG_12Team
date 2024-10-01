using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IScene
{
    void OnShow();
    public string Name { get; set; }
    IScene GetNextScene();
}