import { registerPlayer } from "../clients/PlayerClient";
import { throwToast } from "../hooks/Toast/Toast";
import { PlayerModel } from "../models/PlayerModel";

export default async function registerNewPlayer(playerName : string, roomId : number) {
    if(playerName === '') {
      throwToast("The name cannot be empty!", 'error');
      return;
    }

    let player : PlayerModel = { Name: playerName, RoomId: roomId };
    const result = await registerPlayer(player);

    if(!result.isSuccessful) {
      throwToast(result.clientErrorMessage, 'error');
    } else {
      throwToast("Player was created!", 'success');
    }
}