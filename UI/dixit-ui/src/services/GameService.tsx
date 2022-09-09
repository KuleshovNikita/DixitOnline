import registerNewPlayer from "./PlayerService";
import createNewRoom from "./RoomService";

export default function startNewGame(event, playerName : string, roomCode : string | null) : string {
    if(!createNewRoom(roomCode)) {
        return '';
    }

    //registerNewPlayer(playerName);
    event.preventDefault();
}