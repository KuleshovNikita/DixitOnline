import createNewRoomClient from "clients/RoomClient";

export default function createNewRoom(roomCode : string | null) {
    createNewRoomClient(roomCode);
}