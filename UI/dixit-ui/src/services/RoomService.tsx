import createNewRoomClient from "../clients/RoomClient";
import { throwToast } from "../hooks/Toast/Toast";
import { DataServerResult } from "../models/ServerResult";

export default async function createNewRoom(roomCode : string | null) : Promise<DataServerResult> {
    const result = await createNewRoomClient(roomCode);

    if(!result.isSuccessful) {
        throwToast(result.clientErrorMessage, 'error');
    } else {
        throwToast("A new room was created!", 'success');
    }

    return result;
}