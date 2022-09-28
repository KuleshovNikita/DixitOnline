import registerNewPlayer from "./PlayerService";
import createNewRoom from "./RoomService";

export default async function startNewGame(event, playerName : string, roomCode : string | null) 
    : Promise<string> {
        const res = await createNewRoom(roomCode);

        if(!res.isSuccessful) {
            return '';
        }

        await registerNewPlayer(playerName, res.value.roomId);

        event.preventDefault();

        return res.value.roomCode;
}