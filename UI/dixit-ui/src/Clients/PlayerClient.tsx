import { PlayerModel } from "../models/PlayerModel";
import ServerResult from "../models/ServerResult";

export async function registerPlayer(playerModel : PlayerModel) : Promise<ServerResult> {
    return await fetch(process.env.REACT_APP_API_URL + 'players/newPlayer',
    { 
        method: 'POST',
        headers: {
            'Content-Type': "application/json; charset=utf-8"
        },
        body: JSON.stringify(playerModel),
    })
    .then(r => r.json());
}