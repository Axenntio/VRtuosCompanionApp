#include "ui_ConnectForm.h"

#ifndef __ConnectForm_HH_
#define __ConnectForm_HH_

class ConnectForm : public QMainWindow {
    Q_OBJECT
public:
    ConnectForm(QWidget *parent = nullptr);
    Ui::ConnectForm* GetUI() const;

private slots:

private:
    void Save();
    Ui::ConnectForm* _ui;
};

#endif