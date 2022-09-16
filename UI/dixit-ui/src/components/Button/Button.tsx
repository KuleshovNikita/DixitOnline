import * as React from 'react';
import styles from './Button.module.css';
 
export function Button(props) {
    return (
        <button className={styles.btn} {...props}>
            {props.children}
        </button>
    );
}

export default Button;