import { DataServerResult } from "../models/ServerResult";

export default async function createNewRoomClient(roomCode : string | null) 
    : Promise<DataServerResult> {
        return await fetch(process.env.REACT_APP_API_URL + 'rooms/newRoom',
        { 
            method: 'POST',
            headers: {
                'Content-Type': "application/json; charset=utf-8"
            },
            body: JSON.stringify(roomCode),
        })
        .then(resp => resp.json());
}