import React from 'react';
import './App.css';
import './css-common/InputField.css';
import Button from './components/Button/Button';
import PopUpMessage from './components/PopUpMessage/PopUpMessage';

function App() {
  const [playerName, setPlayerName] = React.useState('');
  const [isError, setIsError] = React.useState(false);

  return (
    <div className="App">
        <h1>Dixit Online</h1>
        <input className="InputField" placeholder='Enter your name' type={"text"} onChange={handleChange}/>
        <Button onClick={registerNewPlayer}>Start New Game</Button> 
        <Button>Connect To The Room</Button>
        { isError && <PopUpMessage message="Name cannot be empty!" type='error' showMessage={() => showPopup(false)}/> }
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

    fetch('https://localhost:44303/players/newPlayer',
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

export default App;
