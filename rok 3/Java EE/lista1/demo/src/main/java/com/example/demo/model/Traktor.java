package com.example.demo.model;

import jakarta.persistence.Entity;

@Entity
public class Traktor extends Pojazd {
    private Boolean czy_kabina;
    private Integer moc;
}
