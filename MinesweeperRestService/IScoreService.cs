/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
using MinesweeperRestService.Models;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Minesweeper
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IScoreService
    {
        //Routing for the users high score
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScoresById/{id}")]
        RestDTO GetScoresById(string id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScoresByUsername/{id}")]
        RestDTO GetScoresByUsername(string id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetTopTenScores/{boardSize}/{difficulty}")]
        RestDTO GetTopTenScores(string boardSize, string difficulty);
    }
}