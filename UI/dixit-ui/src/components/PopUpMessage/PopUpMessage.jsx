import React from 'react';
import styles from './PopUpMessage.module.css';
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
    return messageType[0].toUpperCase() + messageType.substring(1).toLowerCase();
  }

  console.log(normalizeMessageType(type));

  return (
    <TransitionGroup>
      <CSSTransition timeout={500} classNames={styles.popup}>
        <div className={[styles.popup, styles[type.toUpperCase()]].join(" ")}>
          <div id={styles.messageType}>
            {normalizeMessageType(type)}
          </div>
          <div id={styles.messageBtnBox}>
            <button id={styles.messageBtn} onClick={showMessage}>
              <b>Close</b>
            </button>
          </div>
          <div id={styles.messageText}>{message}</div>
        </div>
      </CSSTransition>
    </TransitionGroup>
  );
}

export default PopUpMessage;