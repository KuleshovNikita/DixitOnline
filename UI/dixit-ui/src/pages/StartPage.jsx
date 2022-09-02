import React from 'react';
import InputField from '../components/InputField/InputField';
import Button from '../components/Button/Button';
import PopUpMessage from '../components/PopUpMessage/PopUpMessage';
import styles from './StartPage.module.css';

function StartPage() {
  const [playerName, setPlayerName] = React.useState('');
  const [isError, setIsError] = React.useState(false);

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
        <Button>Connect To The Room</Button>
        { isError && 
            <PopUpMessage message="Name cannot be empty!" type='error' showMessage={() => showPopup(false)}/> 
        }
    </div>
  );

  function showPopup(toggle) {
    setIsError(toggle);
  }

  function handleChange(event) {
    setPlayerName(event.target.value);
  }

  function registerNewPlayer(event) {
    if(playerName === '') {
      setIsError(true);
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
