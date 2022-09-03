import React from 'react';
import InputField from '../components/InputField/InputField';
import Button from '../components/Button/Button';
import styles from './StartPage.module.css';
import { throwToast } from '../hooks/Toast/Toast';

import 'react-toastify/dist/ReactToastify.css';

function StartPage() {
  const [playerName, setPlayerName] = React.useState('');

  return (
    <div className={styles.page}>
      <h1>Dixit Online</h1>
      <InputField minLength={1} 
                  maxLength={20} 
                  placeholder='Enter your name' 
                  type={"text"} 
                  onChange={handleChange}
      />
      <Button onClick={registerNewPlayer}>Start New Game</Button> 
      <Button disabled>Connect To The Room</Button>
    </div>
  );

  function handleChange(event) {
    setPlayerName(event.target.value);
  }

  function registerNewPlayer(event) {
    if(playerName === '') {
      throwToast("The name cannot be empty!", 'error');
      return;
    }

    var player = {Name: playerName};

    fetch(process.env.REACT_APP_API_URL + 'players/newPlayer',
    { method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': "application/json;charset=utf-8"
      },
      body: JSON.stringify(player),
    }).catch(err => console.log(err));

    event.preventDefault();
  }
}

export default StartPage;
