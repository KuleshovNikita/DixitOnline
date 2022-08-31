import styles from './InputField.module.css';

function InputField(props) {
  return (
    <input {...props} className={styles.inputField} />
  );
}

export default InputField;
