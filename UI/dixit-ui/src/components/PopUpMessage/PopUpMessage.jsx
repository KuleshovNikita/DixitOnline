import React from 'react';
import './PopUpMessage.jsx.css';
import {
  CSSTransition,
  TransitionGroup,
} from 'react-transition-group';

const messageTypes = [
  'INFO',
  'WARNING',
  'ERROR'
]

const PopUpMessage = function ({message, type, showMessage}) {
  if(!messageTypes.includes(type.toUpperCase())) {
    throw new Error("Provided pop-up message type '" + type + "' doesn't exist");
  }

  function normalizeMessageType(messageType) {
    return messageType[0].toUpperCase() + messageType.substring(1);
  }

  return (
    <TransitionGroup>
      <CSSTransition timeout={500} classNames="popup">
        <div className={"popup" + " " + type.toUpperCase()}>
          <div id='message-type'>
            {normalizeMessageType(type)}
          </div>
          <div id='message-btn-box'>
            <button id='message-btn' onClick={showMessage}>
              <b>Close</b>
            </button>
          </div>
          <div id='message-text'>{message}</div>
        </div>
      </CSSTransition>
    </TransitionGroup>
  );
}

export default PopUpMessage;