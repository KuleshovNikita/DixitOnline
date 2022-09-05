import { registerPlayer } from "clients/PlayerClient";
import { throwToast } from "hooks/Toast/Toast";
import { PlayerModel } from "models/PlayerModel";

export default function registerNewPlayer(playerName : string) {
    if(playerName === '') {
      throwToast("The name cannot be empty!", 'error');
      return;
    }

    let player : PlayerModel = { Name: playerName };
    registerPlayer(player);
}