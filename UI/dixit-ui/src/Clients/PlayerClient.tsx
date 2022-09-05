import { PlayerModel } from "../models/PlayerModel";

export function registerPlayer(playerModel : PlayerModel) {
    fetch(process.env.REACT_APP_API_URL + 'players/newPlayer',
    { 
        method: 'POST',
        headers: {
            'Content-Type': "application/json; charset=utf-8"
        },
        body: JSON.stringify(playerModel),
    })
    .catch(err => console.log(err));
}