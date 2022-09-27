import createNewRoomClient from "../clients/RoomClient";
import { throwToast } from "../hooks/Toast/Toast";

export default async function createNewRoom(roomCode : string | null) : Promise<string> {
    const result = await createNewRoomClient(roomCode);

    if(!result.isSuccessful) {
        throwToast(result.clientErrorMessage, 'error');
    } else {
        throwToast("A new room was created!", 'success');
        return result.roomCode;
    }
}