import * as React from 'react';
import InputField from '../components/InputField/InputField';
import Button from '../components/Button/Button';
import styles from './StartPage.module.css';
import registerNewPlayer from 'services/PlayerService';
import { throwToast } from 'hooks/Toast/Toast';

function StartPage() {
  const [playerName, setPlayerName] = React.useState('');
  const [roomBtnProps, setRoomBtnProps] = React.useState({disabled: true});

  return (
    <div className={styles.page}>
      <h1>Dixit Online</h1>
      <InputField minLength={1} 
                  maxLength={20} 
                  placeholder='Enter your name' 
                  type={"text"} 
                  onChange={handleNameFieldChange}
                  style={{marginTop: '0px'}}
      />
      <InputField minLength={1} 
                  maxLength={20} 
                  placeholder='Enter room code or supply a new one' 
                  type={"text"} 
                  onChange={handleRoomFieldChange}
                  style={{marginTop: '0px'}}
      />
      <div id={styles.buttonsSet}>
        <Button onClick={event => registerNewPlayer(event, playerName)}>Start New Game</Button>
        <Button onClick={() => throwToast('This stuff is not implemented yet', 'error')} {...roomBtnProps}>Connect To The Room</Button>
      </div>
    </div>
  );

  function handleNameFieldChange(event) {
    setPlayerName(event.target.value);
  }

  function handleRoomFieldChange(event) {
    if(event.target.value !== '') {
      setRoomBtnProps({disabled: false});
    } else {
      setRoomBtnProps({disabled: true});
    }
  }
}

export default StartPage;
