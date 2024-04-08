package com.example.demo.model;

import jakarta.persistence.Entity;

@Entity
public class Gad extends Zwierze{
    private Boolean czy_konczyny;

    public Boolean getCzy_konczyny() {
        return czy_konczyny;
    }

    public void setCzy_konczyny(Boolean czy_konczyny) {
        this.czy_konczyny = czy_konczyny;
    }
}
