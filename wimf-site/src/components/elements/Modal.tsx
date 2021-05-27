import Modal from 'react-bootstrap/Modal';
import React from 'react';

interface ModalBoxProps {
  isOpen: boolean;
  handleClose: () => void;
  children?: React.ReactChild;
  title?: string;
}

export const ModalBox: React.FC<ModalBoxProps> = ({
  isOpen,
  handleClose,
  children,
  title,
}) => (
  <Modal show={isOpen} onHide={handleClose} animation={true}>
    <Modal.Header closeButton>
      <Modal.Title>{title}</Modal.Title>
    </Modal.Header>
    <Modal.Body>{children}</Modal.Body>
  </Modal>
);
