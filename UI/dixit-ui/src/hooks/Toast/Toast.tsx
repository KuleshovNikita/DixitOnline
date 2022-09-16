import { toast } from 'react-toastify';
import { ToastType } from '../../models/ToastType';

export function throwToast(message : string, type : ToastType) {
    toast(message, { type: type });
}